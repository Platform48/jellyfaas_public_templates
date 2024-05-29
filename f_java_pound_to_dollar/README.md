# Template Function: pound_to_dollar in `java`
Example: Sample JellyFaaS function to convert a pound to a dollar.

### Getting started and running:

- ``mvn install``

Then run :

```
mvn clean package
mvn function:run
```

## Deploying to JellyFaaS
### Modifying the yaml file 

You will need to modify the `p48spec.yml` file.

It currently looks like this:

```yaml
# p48spec.yml
name: GBP to Dollar Converter
shortname: javagbptodollar
runtime: java21
entrypoint: jfv1.ConvertGBPToUSDFunction
description: Converts pounds to dollars, takes a query param gbp - outputs json
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









# f_java_pound_to_dollar
java version of £ to $

zip -x "*.git*" -r f_java_pound_to_dollar.zip f_java_pound_to_dollar

Install Maven

mvn clean package
mvn function:run