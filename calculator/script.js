// Code goes here

/*

1. The user interface should be basic, meaning: 
        a) If you are doing a console app, it should take a simple input representing the calculation to perform and, on enter, write the output. 
        b) If you are doing a web page, the UI will consist only of a textbox and a button. 

Numeric pads, buttons for each operator, or other UI elements are not required for the application. 

2. The desired capabilities of the calculator are: 

        a) Addition 
                input: 1+1 
                output: 2 


        b) Subtraction 
                Input: 3-2 
                Output: 1 


        c) Division 
                Input: 10/2 
                Output: 5 


        d) Multiplication 
                Input: 5*2 
                Output: 10 


        e) Square root 
                Input: sqrt(4) 
                Output: 2 


        f) Exponents(Power of) 
                Input: 2^3 
                Output: 8 


        g) Process multiple operations: 
                Input: 6+3-5 
                Output: 4 


        h) Preserve precedence and order of evaluation
        ( Exponents > 
           Square root > 
           Multiplication > 
           Division > 
           Addition > 
           Subtraction ) 
                Input: 40+5-6*sqrt(16) 
                Output: 21 


        i) Validate input 


*/

var app = angular.module('Calculator', []);

app.controller('MainController', function($scope) {

  $scope.userInput = '';
  $scope.result = 0;

  $scope.calc = function() {
    $scope.result = parseOperators($scope.userInput);
  };

  parseOperators = function(_input) {
    var stack = new Array();

    // Exponents 
    var matches = _input.match(/\d+\^\d+/g);
    while (matches && matches.length > 0) {
      for (var i = 0; i < matches.length; i++) {
        var match = matches[i];
        var base = parseInt(match.split('^')[0]);
        var exp = parseInt(match.split('^')[1]);
        var result = Math.pow(base, exp);
        $scope.exp = _input = _input.replace(match, ' ' + result + ' ');
      }
      matches = _input.match(/\d+\^\d+/g);
    }
    //square roots
    matches = _input.match(/sqrt\(\d+\)/g);
    if (matches && matches.length > 0) {
      for (var i = 0; i < matches.length; i++) {
        var match = matches[i];
        var base = match.match(/\d+/)[0];

        var result = Math.sqrt(base);
        $scope.sqrt = _input = _input.replace(match, ' ' + result + ' ');
      }
    }
    //Multiplication 
    matches = _input.match(/\d+\.*\d*\s*\*\s*\d+\.*\d*/g);
    while (matches && matches.length > 0) {
      for (var i = 0; i < matches.length; i++) {
        var match = matches[i];
        var op1 = parseFloat(match.split('*')[0]);
        var op2 = parseFloat(match.split('*')[1]);
        var result = op1 * op2;
        $scope.mult = _input = _input.replace(match, ' ' + result + ' ');
      }
      matches = _input.match(/\d+\.*\d*\s*\*\s*\d+\.*\d*/g);
    }
    //Division 
    matches = _input.match(/\d+\/\d+/g);
    while (matches && matches.length > 0) {
      for (var i = 0; i < matches.length; i++) {
        var match = matches[i];
        var op1 = parseInt(match.split('/')[0]);
        var op2 = parseInt(match.split('/')[1]);
        var result = op1 / op2;
        $scope.div = _input = _input.replace(match, ' ' + result + ' ');
      }
      matches = _input.match(/\d+\/\d+/g);

    }

    //Addition 
    matches = _input.match(/\d+\.*\d*\s*\+\s*\d+\.*\d*/g);
    while (matches && matches.length > 0) {
      for (var i = 0; i < matches.length; i++) {
        var match = matches[i];
        var op1 = parseInt(match.split('+')[0]);
        var op2 = parseInt(match.split('+')[1]);
        var result = op1 + op2;
        $scope.add = _input = _input.replace(match, ' ' + result + ' ');
      }
      matches = _input.match(/\d+\.*\d*\s*\+\s*\d+\.*\d*/g);

    }
    //Substraction 
    matches = _input.match(/\d+\.*\d*\s*-\s*\d+\.*\d*/g);
    while (matches && matches.length > 0) {
      for (var i = 0; i < matches.length; i++) {
        var match = matches[i];
        var op1 = parseInt(match.split('-')[0]);
        var op2 = parseInt(match.split('-')[1]);
        var result = op1 - op2;
        $scope.sub = _input = _input.replace(match, ' ' + result + ' ');
      }
      matches = _input.match(/\d+\.*\d*\s*-\s*\d+\.*\d*/g);

    }
    return _input;
  }


});