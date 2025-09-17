FROM docker.io/library/node:22.18.0 AS build

# Copy cert and install it
WORKDIR /app
COPY Frontend/package*.json ./
RUN npm install 


COPY Frontend/ ./
RUN npm run build

FROM docker.io/library/nginx:alpine

COPY --from=build /app/dist /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
