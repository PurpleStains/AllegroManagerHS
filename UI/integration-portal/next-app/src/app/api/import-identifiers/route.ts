import { NextRequest, NextResponse } from "next/server";
import { getServerSession } from "next-auth";
import { authOptions } from "../../../lib/next-auth-options";

export const POST = async (req: NextRequest) => {

  try {
    const session = await getServerSession(authOptions);
    if (!session?.access_token) {
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
          Authorization: `Bearer ${session?.access_token}`,
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
