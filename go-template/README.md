# Template function for `go`

> This template has everything you need to get started with writing your function!

## Getting started

- For `mac/*nix` run: `FUNCTION_TARGET=Example LOCAL_ONLY=true go run cmd/main.go`
- For `windows`(note using **cmd**, not **powershell**): `set "FUNCTION_TARGET=Example" && set "LOCAL_ONLY=true" && go run cmd/main.go`

## Compiling and Deploying

- Make sure your `jellyspec.json` is up-to-date with your project
- The `shortname` **must** be between 7 - 15 characters
- The `entrypoint` **must** be the name of your function (**cAsE-sEnSiTiVe**).

> You must ensure your API key is valid, and you are registered - you only need to do this once:
`./jellyfaas apikey` (your key is on your profile page on <https://app.jellyfaas.com/profile>)

### Deploying to JellyFaas
>
> `jellyfaas zip -d true -o true` in the same directory as your project
>
> `jellyfaas zip -d true -o true -s <the path to your project>` in a different directory to your project

### Checking for Deployment
>
> `jellyfaas library list` to ensure it's in our library

### Handling deployment errors

If you deployment fails, it will tell you after the deployment steps. However, should you need them
you can list the broken builds and then clean up with the following:

- ``./jellyfaas builds list``
- ``./jellyfaas builds clean --buildId <buildId>``
