function aggregateElements(arr) {
    let sum = 0;
    let sumrep = 0;
    let concat = '';

    for (i = 0; i < arr.length; i++) {
        sum += arr[i];
        sumrep += 1 / arr[i];
        concat += `${arr[i]}`;
    }

    console.log(sum);
    console.log(sumrep);
    console.log(concat);
}

aggregateElements([1, 2, 3]);
aggregateElements([2, 4, 8, 16]);