let numbers=[12,23,34,45,56,67,78];
//access all array elements
for(let i=0;i<numbers.length;i++)
{
    console.log(numbers[i]);
}
console.clear();
for(let i in numbers) //heare i is return as index of the element
{
    console.log(i);
    console.log(numbers[i]);
}
console.clear();
for(let i of numbers) //ES6 feature // here i is return as value of the array element
{
    console.log(i);
}