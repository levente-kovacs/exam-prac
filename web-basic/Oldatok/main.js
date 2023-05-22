const saltInput = document.querySelector('.salt__input');
const waterInput = document.querySelector('.water__input');
const calculateButton = document.querySelector('.calculate__button');
const resultSpan = document.querySelector('#megoldas');

calculateButton.addEventListener('click', () => {
    console.log(saltInput.value);
    console.log(waterInput.value);
    console.log(calculateButton);
    console.log(resultSpan);
    resultSpan.innerHTML = calculate(Number(saltInput.value), Number(waterInput.value));
})

const calculate = (moa, mosz) => {
    return (moa / (mosz + moa)) * 100;
}
