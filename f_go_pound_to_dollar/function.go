package pound_to_dollar

import (
	"encoding/json"
	"fmt"
	"net/http"
	"strconv"

	"github.com/GoogleCloudPlatform/functions-framework-go/functions"
)

// *******************************
// End of wrapper for the function
// *******************************

func init() {
	functions.HTTP("ConvertGBPToUSD", convertGBPToUSD)
}

const exchangeRate = 0.79

type ReturnData struct {
	USDAmount float64 `json:"usd_amount"`
}

func convertGBPToUSD(w http.ResponseWriter, r *http.Request) {

	// Get the GBP amount from the request
	gbpAmountStr := r.URL.Query().Get("gbp")
	gbpAmount, err := strconv.ParseFloat(gbpAmountStr, 64)
	if err != nil {
		http.Error(w, fmt.Sprintf("Invalid GBP amount: %v", err), http.StatusBadRequest)
		return
	}

	if gbpAmount < 0 {
		http.Error(w, "GBP amount must be positive", http.StatusBadRequest)
		return
	}

	// Calculate the USD amount
	usdAmount := gbpAmount * exchangeRate

	// Return the USD amount
	returnData := ReturnData{USDAmount: usdAmount}
	//write into the response
	w.Header().Set("Content-Type", "application/json")
	w.WriteHeader(http.StatusOK)
	json.NewEncoder(w).Encode(returnData)
}
