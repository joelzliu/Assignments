// 1. Salary sum
let salaries = {
    John: 100,
    Ann: 160,
    Pete: 130
};

let sum = 0;
for (let key in salaries) {
    sum += salaries[key];
}
console.log(`Total salaries sum: ${sum}`);

// 2. Create function
function multiplyNumeric(obj) {
    for (let key in obj) {
        if (typeof obj[key] === 'number') {
            obj[key] *= 2;
        }
    }
}

let menu = {
    width: 200,
    height: 300,
    title: "My menu"
};

multiplyNumeric(menu);
console.log(menu);

// 3. Check valid email
function checkEmailId(str) {
    str = str.toLowerCase();
    let atIndex = str.indexOf('@');
    let dotIndex = str.indexOf('.', atIndex);
    return atIndex > 0 && dotIndex > atIndex + 1 && dotIndex < str.length - 1;
}

console.log(checkEmailId("test@example.com")); // true
console.log(checkEmailId("test.example@com")); // false

// 4. Truncate str
function truncate(str, maxlength) {
    if (str.length > maxlength) {
        return str.slice(0, maxlength - 1) + '…';
    }
    return str;
}

console.log(truncate("What I'd like to tell on this topic is:", 20));
console.log(truncate("Hi everyone!", 20));

// 5. Array operations
let arr = ["James", "Brennie"];

arr.push("Robert");
console.log(arr); // ["James", "Brennie", "Robert"]

if (arr.length % 2 === 1) {
    arr[Math.floor(arr.length / 2)] = "Calvin";
}
console.log(arr); // ["James", "Calvin", "Robert"]

let first = arr.shift();
console.log(first); // "James"
console.log(arr); // ["Calvin", "Robert"]

arr.unshift("Rose", "Regal");
console.log(arr); // ["Rose", "Regal", "Calvin", "Robert"]
