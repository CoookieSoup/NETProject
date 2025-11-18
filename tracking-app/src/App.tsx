import React, { useState, useEffect } from 'react';

interface BankTransaction {
  id: number;
  amount: number;
  merchant: string;
  transactionDate: string;
}

function App() {
  const [transactions, setTransactions] = useState<BankTransaction[]>([]);

  useEffect(() => {
    fetch('http://localhost:5238/api/todo/transactions')
      .then(res => res.json())
      .then(data => setTransactions(data))
      .catch(err => console.log('API not running?', err));
  }, []);

  return (
    <div style={{ padding: '20px' }}>
      <h1>Bank Transactions</h1>
      {transactions.map(t => (
        <div key={t.id} style={{ border: '1px solid #ccc', padding: '10px', margin: '5px' }}>
          <h3>{t.merchant}</h3>
          <p>€{t.amount} • {t.merchant} • {new Date(t.transactionDate).toLocaleDateString('lt-LT')}</p>
        </div>
      ))}
      {transactions.length === 0 && <p>No transactions found. Start your API!</p>}
    </div>
  );
}

export default App;