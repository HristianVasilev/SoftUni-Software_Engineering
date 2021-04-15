function splitter(text) {
    const regex = /[A-Za-z0-9]+/g;
    const found = text.match(regex);

    for (i = 0; i < found.length; i++) {
        found[i] = found[i].toUpperCase();
    }

    console.log(found.join(', '));
}

splitter('Hi, how are you?');