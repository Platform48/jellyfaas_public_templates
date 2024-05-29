package jfv1;

import com.google.cloud.functions.HttpFunction;
import com.google.cloud.functions.HttpRequest;
import com.google.cloud.functions.HttpResponse;
import java.io.BufferedWriter;
import java.util.Optional;

public class ConvertGBPToUSDFunction implements HttpFunction {

  // Define the exchange rate constant
  private static final double EXCHANGE_RATE = 0.79;

  @Override
  public void service(final HttpRequest request, final HttpResponse response) throws Exception {
    Optional<String> gbpAmountStr = request.getFirstQueryParameter("gbp");
    
    double gbpAmount;
    try {
      gbpAmount = Double.parseDouble(gbpAmountStr.orElseThrow(() -> new IllegalArgumentException("GBP amount not provided or invalid")));
    } catch (NumberFormatException e) {
      response.setStatusCode(400);
      try (BufferedWriter writer = response.getWriter()) {
        writer.write("{\"error\": \"Invalid GBP amount provided.\"}");
      }
      return;
    }
    
    double usdAmount = gbpAmount * EXCHANGE_RATE;
    
    // Set response type to JSON
    response.setContentType("application/json");
    
    // Write the USD amount to the response
    try (BufferedWriter writer = response.getWriter()) {
      writer.write(String.format("{\"USDAmount\": %.2f}", usdAmount));
    }
  }
}
