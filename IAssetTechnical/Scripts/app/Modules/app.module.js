var WeatherModule = angular.module('weatherModule', []);

WeatherModule.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.interceptors.push(function ($q) {
        return {
            'request': function (config) {
                // when request goes to server reset the error messages.
                $div = angular.element(document.getElementsByClassName('has-error'));
                $div.text('');
                if (config.data && config.data.usemock)
                {
                    config.headers["USE-MOCK"] = config.data.usemock;
                }
                return config || $q.when(config);
            },
            'response': function (response) {                
                return response || $q.when(response);
            },
            'responseError': function (rejection) {
                // do something on error
                $div = angular.element(document.getElementsByClassName('has-error'));
                $div.text(rejection.data.Message);               
                return {data:{}};
            }
        }
    });
}]);
