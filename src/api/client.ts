import type { ClientDto, GoodDto, ShopDto } from '../types';

async function request<T>(url: string, options?: RequestInit): Promise<T> {
  const response = await fetch(`https://localhost:44395${url}`, {
    headers: { 'Content-Type': 'application/json' },
    ...options,
  });
  if (!response.ok) {
    throw new Error(`Ошибка запроса: ${response.status}`);
  }
  if (response.status === 204) return undefined as T;
  return response.json();
}

// ==================== КЛИЕНТЫ ====================
export const clientApi = {
  getAll: () => request<ClientDto[]>('/api/clients'),
  getById: (id: number) => request<ClientDto>(`/api/clients/${id}`),
  create: (client: Omit<ClientDto, 'id' | 'age'>) =>
    request<ClientDto>('/api/clients', {
      method: 'POST',
      body: JSON.stringify(client),
    }),
  update: (id: number, client: Omit<ClientDto, 'age'>) =>
    request<ClientDto>(`/api/clients/${id}`, {
      method: 'PUT',
      body: JSON.stringify(client),
    }),
  delete: (id: number) =>
    request<void>(`/api/clients/${id}`, { method: 'DELETE' }),
};

// ==================== ТОВАРЫ ====================
export const goodApi = {
  getAll: () => request<GoodDto[]>('/api/goods'),
  getById: (id: number) => request<GoodDto>(`/api/goods/${id}`),
  create: (good: Omit<GoodDto, 'id'>) =>
    request<GoodDto>('/api/goods', {
      method: 'POST',
      body: JSON.stringify(good),
    }),
  update: (id: number, good: GoodDto) =>
    request<GoodDto>(`/api/goods/${id}`, {
      method: 'PUT',
      body: JSON.stringify(good),
    }),
  delete: (id: number) =>
    request<void>(`/api/goods/${id}`, { method: 'DELETE' }),
};

// ==================== МАГАЗИНЫ ====================
export const shopApi = {
  getAll: () => request<ShopDto[]>('/api/shops'),
  getById: (id: number) => request<ShopDto>(`/api/shops/${id}`),
  create: (shop: Omit<ShopDto, 'id'>) =>
    request<ShopDto>('/api/shops', {
      method: 'POST',
      body: JSON.stringify(shop),
    }),
  update: (id: number, shop: ShopDto) =>
    request<ShopDto>(`/api/shops/${id}`, {
      method: 'PUT',
      body: JSON.stringify(shop),
    }),
  delete: (id: number) =>
    request<void>(`/api/shops/${id}`, { method: 'DELETE' }),
};