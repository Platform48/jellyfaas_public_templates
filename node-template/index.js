const functions = require('@google-cloud/functions-framework');

functions.http('Example', (req, res) => {
  const name = req.query.name;
  const greetingString = "hello, " + name + "!"
  const returnData = { greeting: greetingString };

  // Set the Content-Type header and send the response
  res.setHeader('Content-Type', 'application/json');
  res.status(200).send(returnData);
});