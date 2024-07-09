import functions_framework
from flask import jsonify

@functions_framework.http
def convert_gbp_to_usd(request):
    """HTTP Cloud Function that greets a given name.
    Args:
        request (flask.Request): The request object.
        <https://flask.palletsprojects.com/en/1.1.x/api/#incoming-request-data>
    Returns:
        A Flask response object with a greeting!
    """
    
    # Try to extract the GBP amount from the query parameters
    name = request.args.get('name')
    if gbp_amount_str is None:
        return jsonify(error="No name provided"), 400

    greeting = "hello, " + name + "!"

    # Return the USD amount in JSON format
    return jsonify(greeting=greeting)

