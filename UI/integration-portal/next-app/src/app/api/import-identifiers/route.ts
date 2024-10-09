import { NextResponse } from "next/server";
import { getToken } from "next-auth/jwt";

export const POST = async (req: Request) => {
  const secret = process.env.NEXTAUTH_SECRET;

  try {
    const token = await getToken({ req, secret });
    if (!token) {
      return NextResponse.json(
        { success: false, message: "Unauthorized" },
        { status: 401 }
      );
    }

    const { idArray } = await req?.json();

    const apiResponse = await fetch(
      "http://localhost:5195/api/myallegro/sale/import",
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify({ offers: idArray }),
      }
    );

    if (!apiResponse.ok) {
      throw new Error("Failed to import identifiers.");
    }

    const data = await apiResponse.json();
    return NextResponse.json({
      success: true,
      message: data.message || "Identifiers successfully imported!",
    });
  } catch (error) {
    return NextResponse.json(
      {
        success: false,
        message: (error as Error).message || "Something went wrong",
      },
      { status: 500 }
    );
  }
};
