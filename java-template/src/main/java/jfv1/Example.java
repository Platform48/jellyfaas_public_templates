package jfv1;

import com.google.cloud.functions.HttpFunction;
import com.google.cloud.functions.HttpRequest;
import com.google.cloud.functions.HttpResponse;
import java.io.BufferedWriter;
import java.util.Optional;

public class Example implements HttpFunction {
  @Override
  public void service(final HttpRequest request, final HttpResponse response) throws Exception {
    Optional<String> name = request.getFirstQueryParameter("name");
    
    // Set response type to JSON
    response.setContentType("application/json");
    String greeting = "hello, " + name + "!";

    // Write the USD amount to the response
    try (BufferedWriter writer = response.getWriter()) {
      writer.write(String.format("{\"greeting\": %s}", greeting));
    }
  }
}
