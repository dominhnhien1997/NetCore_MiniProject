const user = pm.respone.json();
pm.test("Has properties",function() {
    pm.expect(user).to.have.property('displayName'),
    pm.expect(user).to.have.property('userName'),
    pm.expect(user).to.have.property('image'),
    pm.expect(user).to.have.property('token')
})

if (pm.test("Has properties")) {
    pm.globals.set('token',user.token);
}