require 'functions_framework'
require 'json'

FunctionsFramework.http 'convert_gbp_to_usd' do |request|
  # Define the exchange rate constant
  exchange_rate = 0.79

  # Parse the GBP amount from query parameters
  gbp_amount_str = request.params['gbp']
  
  # Initialize response object
  response = {}

  # Validate and convert the GBP amount to float
  begin
    gbp_amount = Float(gbp_amount_str)
  rescue ArgumentError, TypeError
    response[:error] = "Invalid GBP amount provided"
    return [400, {"Content-Type" => "application/json"}, [response.to_json]]
  end

  # Calculate the USD amount
  usd_amount = gbp_amount * exchange_rate

  # Prepare the USD amount response
  response[:USDAmount] = usd_amount.round(2)
  
  # Respond with the calculated USD amount in JSON format
  [200, {"Content-Type" => "application/json"}, [response.to_json]]
end
