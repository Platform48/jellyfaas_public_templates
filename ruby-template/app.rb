require 'functions_framework'
require 'json'

FunctionsFramework.http 'example' do |request|
  name = request.params['name'] || ''
  response = { greeting: "hello, #{name}!" }
  [200, { "Content-Type" => "application/json" }, [response.to_json]]
end
