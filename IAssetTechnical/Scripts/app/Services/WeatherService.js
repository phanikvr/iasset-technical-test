WeatherModule.service('WeatherService', function ($http) {
    this.getCountries = function ()
    {
        return $http({
            method: 'GET',
            url: '/Scripts/app/Modules/countries.json',
            data: {}
        });
    }

    this.getCitiesByCountry = function (input) {

        return $http({
            method: 'GET',
            url: 'api/Weather/GetCities',
            data : input,
            params: {countryName : input.country}
        });
    }

    this.getWeatherForCityAndCountry = function (input) {

        return $http({
            method: 'POST',
            url: 'api/Weather/GetWeather',
            data: input
        });
    }
});