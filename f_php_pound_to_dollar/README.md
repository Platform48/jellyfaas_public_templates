# Template Function: pound_to_dollar in `php`
Example: Sample JellyFaaS function to convert a pound to a dollar.

### Getting started and running:

- ``composer require google/cloud-functions-framework``

Then for `mac/*nix`run :

```bash
export FUNCTION_TARGET=convertGBPToUSD
php -S localhost:8080 vendor/google/cloud-functions-framework/router.php
```

or on win32 (*note using cmd, not powershell*):

- ``set "FUNCTION_TARGET=convertGBPToUSD" && php -S localhost:8080 vendor/google/cloud-functions-framework/router.php`` 


## Deploying to JellyFaaS
### Modifying the yaml file 

You will need to modify the `p48spec.yml` file.

It currently looks like this:

```yaml
# p48spec.yml
name: GBP to Dollar Converter
shortname: phpgbptodollar
description: Converts pounds to dollars, takes a query param gbp - outputs json
runtime: php82
entrypoint: ConvertGBPToUSD
requirements:
  - requestType: GET
    queryParams:
      - name: gbp
        required: true
        description: The amount in GBP to convert to USD
        example: gbp=100
    outputSchema:
      type: object
      properties:
        usd:
          type: float
          description: The amount in USD
          example: '{"usd":"120.0"}'
```

You will need to give it a unique `shortname`, this has a max of 15 characters. 


### Getting Ready for deployment

Second, you need to zip up the directory, so ensure you are NOT in the directory, but the level above. Then run the following command:

- ``zip -x "*.git*" "*.idea*" -r <foldername>.zip <folder>``

*Note currently the zipfile must be the same name as the folder.*

### Deployment using the CLI

Run the following command(s)

- `./p48cli apikey -e <email> -p <password>`

You only need to do this once, it will create a `.p48` file in you home directory. If you have alredy ran this, you need to just deploy:

- `./p48cli deploy -z <zipfile.zip>`

This may take a few minutes to deploy into JellyFaaS.

### Validating deployment

You can now run the following command to see if the function has deployed?

- ``./p48cli library list``

You can also then get more details on the function, including the API URL to call out too:

- ``./p48cli library -d <shortname>``


## Handling deployment errors

If you have an error it will also list out the error so you can clean up or fix the file and redeploy. Or you can list the broken builds and then clean up with the following commands:

- ``./p48cli builds list``
- ``./p48cli builds clean --buildId <buildId>``














# f_php_pound_to_dollar
php version of £ to $

zip -x "*.git*" -r f_php_pound_to_dollar.zip f_php_pound_to_dollar

composer require google/cloud-functions-framework

(mac/*nix)
export FUNCTION_TARGET=convertGBPToUSD
php -S localhost:8080 vendor/google/cloud-functions-framework/router.php

win32 (cmd.exe not powershell)
set "FUNCTION_TARGET=convertGBPToUSD" && php -S localhost:8080 vendor/google/cloud-functions-framework/router.php