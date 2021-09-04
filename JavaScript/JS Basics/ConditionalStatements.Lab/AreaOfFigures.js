function CalculateArea(input) {
    let shapeType = String(input[0]);
    let a = Number(input[1]); 
    let result;

    switch (shapeType) {
        case "square":           
            result = a * a;
            break;
        case "rectangle":
            let b = Number(input[2]);
            result = a * b;
            break;
        case "circle":
            let radius = a;
            result = Math.PI * radius * radius;
            break;
        case "triangle":
            let h = Number(input[2]);
            result = (a * h) / 2;
            break;
    }

    console.log(result.toFixed(3));
}

CalculateArea(["square", "5"]);
CalculateArea(["rectangle","7","2.5"]);
CalculateArea(["circle","6"]);
CalculateArea(["triangle","4.5","20"]);




