# Mission 10 Assignment
- By Noah Hicks

## Introduction
This project is designed to fulfill the requirements of the Mission 10 Assignment. It features a React frontend that interacts with an ASP.NET Core backend to display information about bowlers from the Bowling League Database. Specifically, it lists bowlers who are members of either the Marlins or Sharks teams, displaying their names, team names, addresses, cities, states, zip codes, and phone numbers.

## Running this Project
To run this project, you will need to have .NET Core and Node.js installed on your machine. Follow the steps below to get the project up and running:

### Backend Setup
1. Navigate to the `backend` directory from the root of the project in Visual Studio.
2. Run the solution file in ISS Express.

### Frontend Setup
1. Navigate to the `frontend` directory from the root of the project.
2. Install the necessary Node.js dependencies by running: `npm install`
3. Start the React development server by running: `npm start`

## Usage
Once both the frontend and backend servers are running, you can view the application by visiting `http://localhost:3000` in your web browser. The application displays a list of bowlers from the Marlins and Sharks teams, including their contact information and team affiliation.

## Features
- Display bowler information in a table format.
- Utilizes the Repository pattern in the backend for data access.
- Responsive web design using Bootstrap.