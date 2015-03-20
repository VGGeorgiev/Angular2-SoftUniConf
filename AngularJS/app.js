var app = angular.module('softUniApp', ['ngRoute'])
	.config(function ($routeProvider) {
		$routeProvider.when('/', {
			templateUrl: 'templates/home.html',
			controller: 'SoftUniController'
		})
	});

app.controller('SoftUniController', function ($scope, SoftUniStore) {
	$scope.title = 'SoftUni Dudes';
	$scope.dudes = SoftUniStore.list;
	$scope.dude = {};

	$scope.addDude = function addDude(event, newDude) {
		if(event.which === 13) {
			if (newDude.name) {
				SoftUniStore.addDude({
					name: newDude.name
				});

				$scope.dude.name = '';
			}; 
		}
	}

	$scope.removeDude = function removeDude(dude) {
		SoftUniStore.removeDude(dude);
	}
});