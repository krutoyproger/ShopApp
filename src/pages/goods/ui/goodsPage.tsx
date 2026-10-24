import { useEffect, useState } from 'react';
import { goodApi } from '../../../api/client'; // Если здесь 3 точки подчеркнуты красным, замени на ../../api/client
import type { GoodDto } from '../../../types';

export const GoodsPage = () => {
  const [goods, setGoods] = useState<GoodDto[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    goodApi
      .getAll()
      .then(setGoods)
      .catch((e) => console.error(e))
      .finally(() => setLoading(false));
  }, []);

  if (loading) return <div style={{ padding: 20 }}>Загрузка...</div>;

  return (
    <>
      <h1>Магазин — Товары</h1>
      <table border={1} cellPadding={8} style={{ borderCollapse: 'collapse', width: '100%' }}>
        <thead style={{ background: '#f0f0f0' }}>
          <tr><th>ID</th><th>Название</th><th>Код</th></tr>
        </thead>
        <tbody>
          {goods.map((g) => (
            <tr key={g.id}>
              <td>{g.id}</td>
              <td>{g.name}</td>
              <td>{g.code}</td>
            </tr>
          ))}
        </tbody>
      </table>
      <p style={{ marginTop: 16, color: '#666' }}>Всего товаров: {goods.length}</p>
    </>
  );
};