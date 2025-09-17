# Use the official PostgreSQL image from the Docker Hub
FROM postgres:latest

# Set environment variables for the database
# Note: For production, use a more secure way to handle passwords, such as Docker secrets.
ENV POSTGRES_USER orgaadmin
ENV POSTGRES_PASSWORD More2!Jazz
ENV POSTGRES_DB orgatoolsdb

# Expose the default PostgreSQL port
EXPOSE 5432

# Optional: You can add a healthcheck to verify that the database is running
# HEALTHCHECK --interval=5s --timeout=5s --retries=5 CMD pg_isready -U $POSTGRES_USER -d $POSTGRES_DB || exit 1

# The default command for the postgres image is to start the server.
# You can add custom initialization scripts to /docker-entrypoint-initdb.d/
# For example, to create tables or seed data.
# COPY init.sql /docker-entrypoint-initdb.d/
