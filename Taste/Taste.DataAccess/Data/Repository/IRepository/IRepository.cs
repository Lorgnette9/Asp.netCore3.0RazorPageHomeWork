using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Taste.DataAccess.Data.Repository.IRepository
{
    //burada T menu olabilir category olabilir service olabilir o yüzden generic 
    // T yi sınıf diye belirtiyoruz cünkü kategori bir sınıf 
    public interface IRepository<T> where T:class
    {

        T Get(int id);      // bize T türünde döndürecek category yani



        /* ------IQueryable için acıklama---------------------
         Bu arabirim, OrderBy ThenBy veya OrderByDescending yöntemini ThenByDescendingçağıran
        bir sıralama sorgusunun sonucunu temsil eder. Çağrıldığında ve bir sıralama sorgusunu temsil eden
        bir ifade ağacını geçtiğinde,
        sonuçta elde edilen IQueryable nesne, uygulayan IOrderedQueryablebir türde olmalıdır. */
        IEnumerable<T> GetAll(
            //nesne ise dönen burdan geçer
            Expression<Func<T, bool>> filter = null, 

            //Arabirim IOrderedQueryable , sorgu sağlayıcıları tarafından uygulamaya yöneliktir.
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null     //porperty olmasını istemiyoruz buraya gelenin

        );


        /*  ---FirstOrDefault----
         *Eğer dizi içinden sadece bir tane sayı seçmek istiyorsak ve seçim şartımız sağlanmıyorsa,
         * bu durumda int tipinin varsayılan seçimde istenen şartta ilk eleman seçilir.     
         */
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null

        );

        void Add(T  enetity);

        void Remove(T entity);  // user passess category ID  we can remove  the entity base on the I.D.
        void Remove(int id);    //implement remove by user passes  the complete entity  and we remove that forum our database

      




    }
}
