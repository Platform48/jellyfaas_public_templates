<?php
use Google\CloudFunctions\FunctionsFramework;
use Psr\Http\Message\ServerRequestInterface;

// Register the function with Functions Framework.
FunctionsFramework::http('ConvertGBPToUSD', 'convertGBPToUSD');

function convertGBPToUSD(ServerRequestInterface $request): string
{
    // Define the exchange rate as a variable
    $exchangeRate = 0.79;
    
    // Get the GBP amount from the query parameters
    $queryParams = $request->getQueryParams();
    $gbpAmountStr = $queryParams['gbp'] ?? '';
    $gbpAmount = floatval($gbpAmountStr);

    // Validate the GBP amount
    if ($gbpAmount <= 0) {
        return json_encode(['error' => sprintf('Invalid GBP amount: %s', htmlspecialchars($gbpAmountStr))]);
    }

    // Calculate the USD amount
    $usdAmount = $gbpAmount * $exchangeRate;

    // Prepare the return data
    $returnData = ['USDAmount' => $usdAmount];

    // Return the response as JSON
    return json_encode($returnData);
}
