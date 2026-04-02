// cartUtils.js

// Arrow function to calculate total cart value
export const calculateTotal = (products) =>
  products
    .map(product => product.price * product.quantity)
    .reduce((sum, value) => sum + value, 0);