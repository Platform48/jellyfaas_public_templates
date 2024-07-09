# JellyFaas public templates

- Go
- Java
- Node
- Php
- Python
- Ruby

## Compiling and Deploying
- Make sure your `p48spec.yml` is up-to-date with your project
- The `shortname` **must** be between 7 - 15 characters
- The `entrypoint` **must** be the name of your function (**cAsE-sEnSiTiVe**).

> You must ensure your API key is valid, and you are registered - you only need to do this once:
`./p48cli apikey -e <email> -p <password>`

### Deploying to JellyFaas
> `p48cli zip -d true -o true` in the same directory as your project

> `p48cli zip -d true -o true -s <the path to your project>` in a different directory to your project

### Checking for Deployment
> `p48cli library list` to ensure it's in our library

### Handling deployment errors
If you deployment fails, it will tell you after the deployment steps. However, should you need them
you can list the broken builds and then clean up with the following:

- ``./p48cli builds list``
- ``./p48cli builds clean --buildId <buildId>``

