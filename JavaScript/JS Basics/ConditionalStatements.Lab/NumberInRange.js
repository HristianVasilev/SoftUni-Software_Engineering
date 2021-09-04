function CheckRange(input){
    let number = Number(input[0]);
    let result;

    if(number < 100){
        result = "Less than 100";
    }
    else if(number >=100 && number <= 200){
        result = "Between 100 and 200";
    }
    else{
        result = "Greater than 200";
    }

    console.log(result);
}