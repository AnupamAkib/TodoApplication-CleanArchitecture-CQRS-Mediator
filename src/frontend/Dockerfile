# Use Node.js LTS version
FROM node:20-alpine

# Set the working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json to install dependencies
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application code into the container
COPY . .

# Expose the port used by the React development server
EXPOSE 3000

# Start the React app in development mode
CMD ["npm", "start"]
