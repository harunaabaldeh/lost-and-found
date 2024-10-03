# Lost Document Finder

A web application designed to help users search for and manage lost documents efficiently. The application enables users to find information about lost items and simplifies the process of tracking and reporting lost documents.

## Table of Contents

- [Features](#features)
- [Technology Stack](#technology-stack)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Search for Lost Documents**: Quickly find lost documents by name or type.
- **User Authentication**: Secure user registration and login.
- **Responsive Design**: User-friendly interface optimized for both desktop and mobile devices.
- **Submissions**: Users can submit lost document reports.

## Technology Stack

- **Backend**: .NET 8 Web API
- **Frontend**: Vue 3 with Vite
- **Styling**: Tailwind CSS
- **Database**: SQLite (preconfigured for easy setup)

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (version 14 or later)
- [Vite](https://vitejs.dev/guide/) (for development)

### Installation

1. **Clone the repository**:

   ```bash
   git clone https://github.com/harunaabaldeh/lost-and-found
   cd lost-and-found
   ```

2. **Setting the backend**

- Navigate to the backend directory
  ```bash
  cd backend/src/API
  ```
- Restore dependencies and run the application
  ```bash
  dotnet restore
  dotnet run
  ```
- The API should now be running at http://localhost:5000 (or another specified port).

3. Set up the frontend

- Open a new terminal and navigate to the frontend directory
  ```bash
  cd frontend/LostDocuments
  ```
- Install dependencies
  ```bash
  npm install
  ```
- Start the development server
  ```bash
  npm run dev
  ```
- The application should now be accessible at http://localhost:5173/
