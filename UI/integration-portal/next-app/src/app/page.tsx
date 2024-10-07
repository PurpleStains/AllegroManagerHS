import Link from "next/link";

export default function Home() {
    return (
        <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100">
          <h2 className="text-3xl font-bold text-gray-800 mb-4">
            Welcome to the Integration Portal
          </h2>
          <p className="text-lg text-gray-600 mb-6 text-center">
            This page is dedicated to sellers that use Baselinker and Allegro.
            <br />
            Sign in to take advantage of this product.
          </p>
          <Link href="/api/auth/signin" className="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600 transition">
              Sign In
          </Link>
        </div>
      );
}