import { useEffect, useState } from 'react';
import { shopApi } from '../../../api/client';
import type { ShopDto } from '../../../types';

export const ShopsPage = () => {
  const [shops, setShops] = useState<ShopDto[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    shopApi.getAll().then(setShops).catch(console.error).finally(() => setLoading(false));
  }, []);

  if (loading) return <div>Загрузка...</div>;

  return (
    <>
      <h1>Магазин — Магазины</h1>
      <table border={1} cellPadding={8} style={{ borderCollapse: 'collapse', width: '100%' }}>
        <thead>
          <tr><th>ID</th><th>Название</th><th>Код</th></tr>
        </thead>
        <tbody>
          {shops.map((s) => (
            <tr key={s.id}><td>{s.id}</td><td>{s.name}</td><td>{s.code}</td></tr>
          ))}
        </tbody>
      </table>
      <p style={{ marginTop: 16, color: '#666' }}>Всего магазинов: {shops.length}</p>
    </>
  );
};  