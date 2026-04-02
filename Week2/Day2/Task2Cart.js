// cart.js
import {calculateTotal} from "./carUtils"

// Store product objects in an array
const cart = [
  { name: "Notebook", price: 50, quantity: 2 },
  { name: "Pen", price: 10, quantity: 5 },
  { name: "Bag", price: 800, quantity: 1 }
];

// Calculate total
const totalAmount = calculateTotal(cart);

// Generate invoice using template literals
const invoice = `
----- Shopping Cart Invoice -----

${cart
  .map(
    item =>
      `${item.name} - ₹${item.price} x ${item.quantity} = ₹${item.price * item.quantity}`
  )
  .join("\n")}

-------------------------------
Total Amount: ₹${totalAmount}
--------------------------------
`;

console.log(invoice);