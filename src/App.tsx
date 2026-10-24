import { useState } from 'react';
import { ClientsPage } from './pages/clients/ui/clientsPage';
import { GoodsPage } from './pages/goods/ui/goodsPage';
import { ShopsPage } from './pages/shops/ui/shopsPage';
import './App.css';

type Page = 'clients' | 'goods' | 'shops';

function App() {
  const [currentPage, setCurrentPage] = useState<Page>('clients');

  return (
    <div style={{ padding: 20, fontFamily: 'Arial, sans-serif', maxWidth: '1000px', margin: '0 auto' }}>
      
      {/* Навигация */}
      <nav style={{ display: 'flex', gap: '10px', marginBottom: '20px', borderBottom: '2px solid #ddd', paddingBottom: '10px' }}>
        <button 
          onClick={() => setCurrentPage('clients')}
          style={{ padding: '10px 20px', fontSize: '16px', cursor: 'pointer', fontWeight: currentPage === 'clients' ? 'bold' : 'normal', background: currentPage === 'clients' ? '#007bff' : '#fff', color: currentPage === 'clients' ? '#fff' : '#000' }}
        >
          Клиенты
        </button>
        <button 
          onClick={() => setCurrentPage('goods')}
          style={{ padding: '10px 20px', fontSize: '16px', cursor: 'pointer', fontWeight: currentPage === 'goods' ? 'bold' : 'normal', background: currentPage === 'goods' ? '#007bff' : '#fff', color: currentPage === 'goods' ? '#fff' : '#000' }}
        >
          Товары
        </button>
        <button 
          onClick={() => setCurrentPage('shops')}
          style={{ padding: '10px 20px', fontSize: '16px', cursor: 'pointer', fontWeight: currentPage === 'shops' ? 'bold' : 'normal', background: currentPage === 'shops' ? '#007bff' : '#fff', color: currentPage === 'shops' ? '#fff' : '#000' }}
        >
          Магазины
        </button>
      </nav>

      {/* Отображение текущей страницы */}
      <main>
        {currentPage === 'clients' && <ClientsPage />}
        {currentPage === 'goods' && <GoodsPage />}
        {currentPage === 'shops' && <ShopsPage />}
      </main>
      
    </div>
  );
}

export default App;