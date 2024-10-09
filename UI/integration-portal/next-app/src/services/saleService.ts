import { getToken } from "next-auth/jwt";

export interface ImportIdentifiersResponse {
  success: boolean;
  message: string;
}

export const importIdentifiers = async (
  identifiers: string[]
): Promise<ImportIdentifiersResponse> => {
  try {
    const response = await fetch("http://localhost:8081/api/sale/import", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ identifiers }),
    });

    if (!response.ok) {
      throw new Error("Failed to import identifiers.");
    }

    const data = await response.json();
    return {
      success: true,
      message: data.message || "Identifiers successfully imported!",
    };
  } catch (error) {
    return { success: false, message: (error as Error).message };
  }
};
