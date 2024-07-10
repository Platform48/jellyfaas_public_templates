package example

import (
	"encoding/json"
	"github.com/GoogleCloudPlatform/functions-framework-go/functions"
	"net/http"
)

func init() {
	functions.HTTP("Example", Example)
}

type Response struct {
	Greeting string `json:"greeting"`
}

func Example(w http.ResponseWriter, r *http.Request) {
	name := r.URL.Query().Get("name")
	greeting := "hello, " + name + "!"

	res := Response{Greeting: greeting}

	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusOK)
	json.NewEncoder(w).Encode(res)
}
