import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

//Razbira se ne raboti
//Hitch ne bachka kato pich
public class Examples {
    public static void main(String[] args) {
        Logger.getLogger("org.hibernate").setLevel(Level.SEVERE);
        EntityManagerFactory emf = Persistence
                .createEntityManagerFactory("blog-db");
        EntityManager em = emf.createEntityManager();
        try {
            User newUser = new User();
            newUser.setUsername("pesho" + new Date().getTime());
            newUser.setPasswordHash("pass12345");
            newUser.setFullName("P.Petrov");
            em.persist(newUser);
            System.out.println("Created new user #" + newUser.getId());

            for (int i = 0; i <= 10; i++) {
                Post newPost = new Post();
                newPost.setTitle("Post Title " + i);
                newPost.setBody("<p>Body" + i + "</p");
                newPost.setAuthor(newUser);
                em.persist(newPost);
                System.out.println("Created new post #" + newPost.getId());
            }

            Query allPostsQuerySlow = em.createQuery("SELECT p FROM Post p");

            List<Post> posts = allPostsQuerySlow.getResultList();

            for (Post post : posts) {
                System.out.println(post);
            }

            User firstUser = em.find(User.class, 1L);
            firstUser.setPasswordHash("" + new Date().getTime());
            firstUser.setFullName(firstUser.getFullName() + "2");
            em.getTransaction().begin();
            em.persist(firstUser);
            em.getTransaction().commit();

            System.out.println("Edited existing user #" + firstUser.getId());

            LocalDateTime startDate = LocalDateTime.parse("2016-05-19T12:00:00");
            LocalDateTime endDate = LocalDateTime.now();

            Query postQuery = em.createNativeQuery(
                    "SELECT id,title,date,body,author_id FROM posts " + "WHERE CONVERT(date,Date) " + "BETWEEN :startDate AND :endDate", Post.class).setParameter("startDate",startDate)
                    .setParameter("endDate",endDate);

            List<Post> postsAlls = postQuery.getResultList();

            postsAlls.forEach(System.out::println);
        } finally {
            em.close();
            emf.close();
        }
    }
}