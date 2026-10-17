using Microsoft.AspNetCore.Identity;
using Shop.Domain.Constants;
using Shop.Domain.Entities;
using Shop.Infrastructure.Persistence;

namespace Shop.Infrastructure.Seeders;

internal class ShopSeeder(ShopDbContext dbContext) : IShopSeeder
{
    public async Task Seed()
    {
        if (!dbContext.Roles.Any())
        {
            IEnumerable<IdentityRole> roles = GetRoles();
            await dbContext.AddRangeAsync(roles);
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Users.Any())
        {
            IEnumerable<User> users = GetUsers();
            await dbContext.Users.AddRangeAsync(users);
            await dbContext.SaveChangesAsync();
        }
    }

    private IEnumerable<User> GetUsers()
    {
        IEnumerable<User> users = [
            new()
            {
                Id="0af2138d-b32e-4f83-b6cd-3c162a3f6a0e",
                Email="owner@gmail.com",
                UserName="owner@gmail.com",
                NormalizedEmail="owner@gmail.com".ToUpper(),
                NormalizedUserName="owner@gmail.com".ToUpper(),
                PasswordHash="AQAAAAIAAYagAAAAENpoTL/wfsi6Nc5z+yKJinQLIqX2/yCKgek5hJtJv1l++zT2RsorkUVU+bZ+Oj5iYg==",
            },
            new()
            {
                Id="413da784-ecab-4248-b786-d5c6214b9786",
                Email="user@gmail.com",
                UserName="user@gmail.com",
                NormalizedEmail="user@gmail.com".ToUpper(),
                NormalizedUserName="user@gmail.com".ToUpper(),
                PasswordHash="AQAAAAIAAYagAAAAEHNi4ANzt2MfxyGlv8LxeTjQspQ0x3k1IpqV99sE1sKzyYrT1GFQCQV9UOGuCMGABA==",
            },
            new()
            {
                Id="f875a48f-21b6-4ff2-8d42-bddabb8244f5",
                Email="admin@gmail.com",
                UserName="admin@gmail.com",
                NormalizedEmail="admin@gmail.com".ToUpper(),
                NormalizedUserName="admin@gmail.com".ToUpper(),
                PasswordHash="AQAAAAIAAYagAAAAEIU1Szp0E/AjYLD12A4cXVgHTcwIby+2C/CNEC+CCkAuLBzuQshqZScLuHMEN5tl5g=="
            }
            ];
        return users;
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        IEnumerable<IdentityRole> roles = [
            new(UserRoles.Admin)
            {
                NormalizedName=UserRoles.Admin.ToUpper()
            },
            new(UserRoles.User)
            {
                NormalizedName=UserRoles.User.ToUpper()
            },
            new(UserRoles.Owner)
            {
                NormalizedName=UserRoles.Owner.ToUpper()
            }];
        return roles;
    }
}
