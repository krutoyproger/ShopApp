import { useEffect, useState } from 'react';
import { clientApi } from '../../../api/client';
import type { ClientDto } from '../../../types';

export const ClientsPage = () => {
  const [clients, setClients] = useState<ClientDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    clientApi
      .getAll()
      .then(setClients)
      .catch((e) => setError(e.message))
      .finally(() => setLoading(false));
  }, []);

  if (loading) return <div style={{ padding: 20 }}>Загрузка...</div>;
  if (error) return <div style={{ padding: 20, color: 'red' }}>Ошибка: {error}</div>;

  return (
    <>
      <h1>Магазин — Клиенты</h1>
      <table border={1} cellPadding={8} style={{ borderCollapse: 'collapse', width: '100%' }}>
        <thead style={{ background: '#f0f0f0' }}>
          <tr>
            <th>ID</th>
            <th>Фамилия</th>
            <th>Имя</th>
            <th>Отчество</th>
            <th>Дата рождения</th>
            <th>Возраст</th>
          </tr>
        </thead>
        <tbody>
          {clients.map((c) => (
            <tr key={c.id}>
              <td>{c.id}</td>
              <td>{c.lastName}</td>
              <td>{c.firstName}</td>
              <td>{c.patronymic}</td>
              <td>{new Date(c.birthDate).toLocaleDateString('ru-RU')}</td>
              <td>{c.age}</td>
            </tr>
          ))}
        </tbody>
      </table>
      <p style={{ marginTop: 16, color: '#666' }}>Всего клиентов: {clients.length}</p>
    </>
  );
};