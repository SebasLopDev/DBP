from flask import Flask, render_template, request, redirect, url_for, flash
from flask_sqlalchemy import SQLAlchemy
from sqlalchemy.exc import IntegrityError


app = Flask(__name__)
app.config['DEBUG'] = True 
app.config['SQLALCHEMY_DATABASE_URI'] = 'mysql://root:@localhost/store1'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False  # Agrega esta línea para desactivar el seguimiento de modificaciones
app.config['SECRET_KEY'] = 'una_clave_secreta_aleatoria'
db = SQLAlchemy(app)



class Usuario(db.Model):    
    id = db.Column(db.Integer, primary_key=True)  
    nombre = db.Column(db.String(100), nullable=False)
    email = db.Column(db.String(120), unique=True, nullable=False)
    numero_de_personas = db.Column(db.Integer, nullable=False)
    hora = db.Column(db.Time, nullable=False)
    fecha = db.Column(db.Date, nullable=False)
   
# Crear todas las tablas
with app.app_context():
    db.create_all() 
    
   

@app.route('/')
def home():
    return render_template('index.html')

@app.route('/login')
def login():
    return render_template('login.html')

@app.route('/galeria')
def galeria():
    return render_template('galeria.html')

# Ruta para el formulario de usuario
@app.route('/crear_usuario', methods=['GET', 'POST'])
def crear_usuario():
    if request.method == 'POST':
        nombre = request.form['nombre']
        email = request.form['email']
        numero_de_personas = int(request.form['numero_de_personas'])
        hora = request.form['hora']
        fecha = request.form['fecha']

        # Crear nuevo usuario
        nuevo_usuario = Usuario(
            nombre=nombre, 
            email=email, 
            numero_de_personas=numero_de_personas, 
            hora=hora, 
            fecha=fecha
        )

        try:
            # Guardar en la base de datos
            db.session.add(nuevo_usuario)
            db.session.commit()
            flash('Usuario registrado con éxito.', 'success')
            return redirect(url_for('login'))
        except IntegrityError:
            db.session.rollback()  # Revierte la transacción en caso de error
            flash('Este correo electrónico ya está registrado. Por favor, elige otro.', 'warning')

    return render_template('login.html')  # Renderiza el formulario nuevamente si hay un error

    
@app.route('/menu')
def menu():
    return render_template('menu.html')

@app.route('/admin')
def admin():
    return render_template('admin.html')




if __name__ == '__main__':
    app.run(debug=True)
     
