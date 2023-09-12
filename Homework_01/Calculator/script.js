class Calculator{
constructor(previousOperandTextElement, currentOperandTextElement) {
    this.previousOperandTextElement = previousOperandTextElement;
    this.currentOperandTextElement = currentOperandTextElement;
    this.clear();
}

clear(){
    this.currentOperand = ''
    this.previousOperand = ''
    this.operantion = undefined;
}
delete(){
this.currentOperand = this.currentOperand.toString().slice(0,-1);
}

appendNumber(number){
    if(number === '.' && this.currentOperand.includes('.')) return//kontrola aby tam nemohlo být víc teček jak jedna.
    this.currentOperand = this.currentOperand.toString() + number.toString();
}

chooseOperantion(operantion){
    if(this.currentOperand === '') return
    if(this.previousOperand !== ''){
        this.compute();
    }
    this.operantion = operantion;
    this.previousOperand = this.currentOperand;
    this.currentOperand = ''
}

compute(){//výpočet
    let computation
    const prev = parseFloat(this.previousOperand)
    const current = parseFloat(this.currentOperand)
    if(isNaN(prev) || isNaN(current)) return
    switch(this.operantion){
        case '+':
            computation = prev + current;
            break
        case '-':
                computation = prev - current;
                break  
        case '*':
            computation = prev * current;
            break   
        case '/':
            computation = prev / current;
            break
        default:
            return
    }
    this.currentOperand = computation;
    this.operantion = undefined;
    this.previousOperand = ''
}

getDisplayNumber(number){
    const stringNumber = number.toString()
    const integerDigits = parseFloat(stringNumber.split('.')[0])
    const decimalDigits = stringNumber.split('.')[1]
    let integerDisplay
    if(isNaN(integerDigits)){
        integerDisplay = ''
    } else {
        integerDisplay = integerDigits.toLocaleString('en',
        {maximumFractionDigits: 0} )
    }
    if(decimalDigits != null){
      return  `${integerDisplay}.${decimalDigits}`
    }else{
        return integerDisplay
    }
}

updateDisplay(){
    this.currentOperandTextElement.innerText =
     this.getDisplayNumber(this.currentOperand);
    if(this.operantion != null){
        this.previousOperandTextElement.innerText = 
        `${this.getDisplayNumber(this.previousOperand)} = ${this.operantion}`
        }else{
           this.previousOperandTextElement.innerText = ''
        }
    }
}


const numberButtons = document.querySelectorAll('[data-number]');
const operationButtons = document.querySelectorAll('[data-operation]');
const equalsButton = document.querySelector('[data-equals]');
const deleteButton = document.querySelector('[data-delete]');
const allClearButton = document.querySelector('[data-all-Clear]');
const previousOperandTextElement = document.querySelector('[data-previous-operand]');
const currentOperandTextElement = document.querySelector('[data-current-operand]');

const calculator = new Calculator(previousOperandTextElement, currentOperandTextElement);

numberButtons.forEach(buttons => {
    buttons.addEventListener('click', () => {
        calculator.appendNumber(buttons.innerText)
        calculator.updateDisplay()
    })
})

operationButtons.forEach(buttons => {
    buttons.addEventListener('click', () => {
        calculator.chooseOperantion(buttons.innerText)
        calculator.updateDisplay()
    })
})

equalsButton.addEventListener('click',button =>{
    calculator.compute()
    calculator.updateDisplay()
})

allClearButton.addEventListener('click',button =>{
    calculator.clear()
    calculator.updateDisplay()
})

deleteButton.addEventListener('click',button =>{
    calculator.delete()
    calculator.updateDisplay()
})


