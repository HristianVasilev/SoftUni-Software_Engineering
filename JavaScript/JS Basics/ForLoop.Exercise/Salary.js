function calculateSalary(input) {
    let salary = Number(input[1]);
    const length = input.length;

    for (let i = 2; i < length; i++) {
        let currentWebSite = String(input[i]);

        switch (currentWebSite) {
            case "Facebook":
                salary -= 150;
                break;
            case "Instagram":
                salary -= 100;
                break;
            case "Reddit":
                salary -= 50;
                break;
        }

        if (salary <= 0) {
            return "You have lost your salary.";
        }
    }

    return salary.toFixed(0);
}

let a = calculateSalary(["10", "750", "Facebook", "Dev.bg", "Instagram", "Facebook", "Reddit", "Facebook", "Facebook"]);

let b = calculateSalary(["3", "500", "Github.com", "Stackoverflow.com", "softuni.bg"]);

let c = calculateSalary(["3", "500", "Facebook", "Stackoverflow.com", "softuni.bg"]);

console.log(c);