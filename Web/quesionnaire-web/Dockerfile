# develop stage
FROM node:11.1-alpine as develop-stage
WORKDIR /
COPY package*.json ./

RUN yarn install --ignore-engines
COPY . .
# # build stage
# FROM develop-stage as build-stage
# RUN yarn build
# # production stage
# FROM nginx:1.15.7-alpine as production-stage
# COPY --from=build-stage /app/dist /usr/share/nginx/html
EXPOSE 8080
CMD ["yarn", "run", "serve"]