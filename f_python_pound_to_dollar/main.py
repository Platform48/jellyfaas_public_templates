import functions_framework
from flask import jsonify

@functions_framework.http
def convert_gbp_to_usd(request):
    """HTTP Cloud Function to convert GBP to USD.
    Args:
        request (flask.Request): The request object.
        <https://flask.palletsprojects.com/en/1.1.x/api/#incoming-request-data>
    Returns:
        A Flask response object with the conversion result in JSON format.
    """
    # Define the exchange rate
    exchange_rate = 0.79
    
    # Try to extract the GBP amount from the query parameters
    gbp_amount_str = request.args.get('gbp')
    if gbp_amount_str is None:
        return jsonify(error="No GBP amount provided"), 400
    
    try:
        gbp_amount = float(gbp_amount_str)
    except ValueError:
        return jsonify(error="Invalid GBP amount"), 400
    
    # Calculate the USD amount
    usd_amount = gbp_amount * exchange_rate
    
    # Return the USD amount in JSON format
    return jsonify(usd_amount=usd_amount)

