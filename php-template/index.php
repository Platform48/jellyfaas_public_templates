<?php
use Google\CloudFunctions\FunctionsFramework;
use Psr\Http\Message\ServerRequestInterface;

// Register the function with Functions Framework.
FunctionsFramework::http('Example', 'example');

function example(ServerRequestInterface $request): string
{
    $queryParams = $request->getQueryParams();
    $name = $queryParams['name'] ?? '';
    $greeting = "hello, " . $name . "!";


    // Prepare the return data
    $returnData = ['greeting' => $greeting];

    // Return the response as JSON
    return json_encode($returnData);
}
