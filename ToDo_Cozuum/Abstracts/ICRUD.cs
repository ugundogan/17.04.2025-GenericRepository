﻿namespace ToDo_Cozuum.Abstracts
{
    public interface ICRUD<TEntity> where TEntity : class 
    {
        void Ekle(TEntity entity);
        void Guncelle(TEntity entity);
        void Sil(int id);
        TEntity Bul(int id);
        List<TEntity> Listele();
    }
}
