FROM nginx:stable-alpine AS base
WORKDIR /usr/share/nginx/html
EXPOSE 80


# Use a transient stage to exclude build artifacts and env vars in production layer
FROM node:24-alpine AS build
ENV NPM_CONFIG_REGISTRY=https://pkg.harness.io/pkg/ct8onj8YTdaXtKaFsYCRLg/org-devtools-npm/npm/
WORKDIR /src
COPY . .
RUN npm config set registry "$NPM_CONFIG_REGISTRY" --location=project && \
    npm config set replace-registry-host always --location=project

# Activate the license using the mounted secret
RUN --mount=type=secret,id=telerik-license-key \
    export TELERIK_LICENSE="$(cat /run/secrets/telerik-license-key)" && \
    npm ci --registry="$NPM_CONFIG_REGISTRY" --replace-registry-host=always && \
    npx --no-install kendo-ui-license activate && \
    npm run build --prod


# Build the final image from the base, copying ONLY the publish artifacts from the build stage
FROM base AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /src/dist/ ./
ENTRYPOINT ["nginx", "-g", "daemon off;"]