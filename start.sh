#!/bin/sh

docker-compose up -d

# wait for the service to be ready
while ! curl --fail --silent --head http://localhost:4200; do
  sleep 1
done

# open the browser window
open http://localhost:4200