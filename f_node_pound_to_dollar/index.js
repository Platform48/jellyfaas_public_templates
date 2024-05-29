const functions = require('@google-cloud/functions-framework');

// Define the exchange rate constant
const exchangeRate = 0.79;

functions.http('convertGBPToUSD', (req, res) => {
  // Get the GBP amount from the query parameters
  const gbpAmountStr = req.query.gbp;
  
  // Attempt to parse the GBP amount to a number
  const gbpAmount = parseFloat(gbpAmountStr);
  
  // Check if the parsing was successful and the value is a valid number
  if (isNaN(gbpAmount)) {
    // Respond with an error message if the parsing failed
    res.status(400).send({ error: `Invalid GBP amount: ${gbpAmountStr}` });
    return;
  }

  // Calculate the USD amount
  const usdAmount = gbpAmount * exchangeRate;

  // Prepare the return data
  const returnData = { USDAmount: usdAmount };

  // Set the Content-Type header and send the response
  res.setHeader('Content-Type', 'application/json');
  res.status(200).send(returnData);
});