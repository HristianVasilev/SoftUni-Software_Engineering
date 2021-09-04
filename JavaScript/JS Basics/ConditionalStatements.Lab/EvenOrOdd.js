function isEvenOrOdd(input){
    let number = Number(input[0]);
    let typeOfNumber;

    if(number % 2 ===0){
        typeOfNumber = "even";
    }
    else{
        typeOfNumber = "odd";
    }

    console.log(typeOfNumber);
}

isEvenOrOdd(["2"]);