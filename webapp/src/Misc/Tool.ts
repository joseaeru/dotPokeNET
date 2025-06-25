function toCamelCase(str: string): string {
    const words = str.match(/[A-Z]{2,}(?=[A-Z][a-z]+[0-9]*|\b)|[A-Z]?[a-z]+[0-9]*|[A-Z]|[0-9]+/g);
    if (!words) {
        return '';
    }
    const capitalizedWords = words.map((word, index) => {
        const firstLetter = word.slice(0, 1).toUpperCase();
        const restOfWord = word.slice(1).toLowerCase();
        return index === 0 ? firstLetter.toLowerCase() + restOfWord : firstLetter + restOfWord;
    });
    return capitalizedWords.join('');
}